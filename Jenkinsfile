pipeline {
  agent {
    dockerfile {
      filename 'Dockerfile'
    }

  }
  stages {
    stage('build') {
      steps {
        sh 'docker build --tag people:dev'
        sh 'docker tag people:dev dawborycki/people:dev'
      }
    }

  }
}