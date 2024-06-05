pipeline {
  agent { label "nix" }
  environment {
    GITHUB_CREDENTIALS_ID = "cjt-jenkins-github-app"
    REPO_URL = 'git@github.com:ChrisJTaylor/match.git'
  }
  stages {
    stage('Clean workspace'){
      steps {
        cleanWs()
      }
    }

    stage('Setup environment'){
      steps {
        bat label: 'Setup nix environment', 
        script: '''
          nix develop
        ''' 
      }
    
    stage('Checkout'){
      steps {
        git branch: 'main', 
        credentialsId: GITHUB_CREDENTIALS_ID,
	url: REPO_URL
      }
    }
    
    stage('Restore packages') {
      steps {
        bat label: 'Restore package dependencies', 
        script: '''
          just restore
        ''' 
      }
    }

    stage('Build') {
      steps {
        bat label: 'Build solution', 
        script: '''
          just build
        ''' 
        }
      }
    }

    stage('Run tests') {
      steps {
        bat label: 'Run all unit tests', 
        script: '''
          just test
        ''' 
        }
      }
    }

    stage('Package') {
      steps {
        bat label: 'Package',
        script: ''' 
	  just package
        '''
      }
    }
  }
}

