pipeline {
  agent { label "nix" }

  stages {

    stage('Restore packages') {
      steps {
        sh label: 'Restore package dependencies', 
        script: '''
          nix-shell --pure --run "just restore"
        ''' 
      }
    }

    stage('Build') {
      steps {
        sh label: 'Build solution', 
        script: '''
          nix-shell --pure --run "just build"
        ''' 
        }
      }

    stage('Run tests') {
      steps {
        sh label: 'Run all unit tests', 
        script: '''
          nix-shell --pure --run "just test"
        ''' 
        }
      }

    stage('Package') {
      steps {
        sh label: 'Package',
        script: ''' 
          nix-shell --pure --run "just package"
        '''
      }
    }
  }
}

