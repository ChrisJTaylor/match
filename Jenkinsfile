pipeline {
  agent { label "nix" }

  stages {

    stage('Setup Nix Environment') {
      steps {
        sh label: 'Ensure Nix environment is ready',
	script: '''
	  sh './run-nix-shell.sh "echo \'Nix environment loaded\'"'
	'''
      }
    }

    stage('Restore packages') {
      steps {
        sh label: 'Restore package dependencies', 
        script: '''
          exec nix-shell --pure --run "just restore"
        ''' 
      }
    }

    stage('Build') {
      steps {
        sh label: 'Build solution', 
        script: '''
          exec nix-shell --pure --run "just build"
        ''' 
        }
      }

    stage('Run tests') {
      steps {
        sh label: 'Run all unit tests', 
        script: '''
          exec nix-shell --pure --run "just test"
        ''' 
        }
      }

    stage('Package') {
      steps {
        sh label: 'Package',
        script: ''' 
          exec nix-shell --pure --run "just package"
        '''
      }
    }
  }
}

