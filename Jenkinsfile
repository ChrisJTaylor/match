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
        script: '''
          nix develop
        ''' 
      }
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
        script: '''
          just restore
        ''' 
      }
    }

    stage('Build') {
      steps {
        script: '''
          just build
        ''' 
        }
      }

    stage('Run tests') {
      steps {
        script: '''
          just test
        ''' 
        }
      }

    stage('Package') {
      steps {
        script: ''' 
	  just package
        '''
      }
    }
  }
}

