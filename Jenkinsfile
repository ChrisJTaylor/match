pipeline {
  agent { label "nix" }

  stages {
    stage('Clean workspace'){
      steps {
        cleanWs()
      }
    }

    stage('Setup environment'){
      steps {
        sh label: 'Setup nix environment', 
        script: '''
          nix develop
        ''' 
      }
    }
    
    stage('Restore packages') {
      steps {
        sh label: 'Restore package dependencies', 
        script: '''
          just restore
        ''' 
      }
    }

    stage('Build') {
      steps {
        sh label: 'Build solution', 
        script: '''
          just build
        ''' 
        }
      }

    stage('Run tests') {
      steps {
        sh label: 'Run all unit tests', 
        script: '''
          just test
        ''' 
        }
      }

    stage('Package') {
      steps {
        sh label: 'Package',
        script: ''' 
	  just package
        '''
      }
    }
  }
}

