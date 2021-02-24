pipeline {
  agent any
  stages {
    stage('build') {
      steps {
        sh 'docker build --tag people:${env.BUILD_NUMBER} -f Dockerfile .'
        sh 'docker tag people:dev dawborycki/people:dev'
      }
    }

  }
}