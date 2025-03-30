# Preparation for Participants
To make sure the workshop runs smoothly and efficiently, participants should complete the following setup steps before the workshop.
1. <b>Install Docker & Docker Compose</b>
  Docker will be used to run containers for various services (Grafana, Prometheus, Loki etc.). Docker Compose will help us manage multi-container applications. Steps: <br>
    <b>Docker Desktop</b> <br>
  • Install Docker Desktop<br>
  • Download Docker Desktop: https://docs.docker.com/desktop/setup/install/windows-install/

    <b>Docker Compose</b> <br>
  • Docker Compose comes pre-installed with Docker Desktop <br>
  • Verify installation by running docker --version and docker-compose --version in your terminal/command prompt.

    What you should verify:<br>
    • Run docker version and docker-compose version to ensure both are installed correctly <br>
    • Make sure Docker is running (check the Docker icon in the system tray for Windows)

2. <b>Install Visual Studio Code</b><br>
   A VSC will help you to write and debug .NET code more efficiently.<br>
   Download from VS Code: https://code.visualstudio.com/

3. <b>Install Git</b><br>
    Git is required to clone repositories and manage code versions. Steps:<br>
    • Download & Install Git: <br>
      o Download Git : https://git-scm.com/downloads<br>
    • Verify Installation: <br>
      o Run git --version  in the terminal/command prompt.<br>
    
    What you should verify:<br>
    • Git is installed correctly and working by running the command git --version

4. <b>Add Git to System PATH (Windows Only)</b><br>
    If Git is installed but not recognized:<br>
       Press Win + R, type sysdm.cpl, and press Enter.<br>
       Go to the <b>Advanced</b> tab and click <b>Environment Variables</b>.<br>
       Under <b>System Variables</b>, find and select Path, then click Edit.<br>
       Click New and add the path to your Git bin and cmd folders. Usually:<br>
       C:\Program Files\Git\bin<br>
       C:\Program Files\Git\cmd<br>
   Click OK and restart your command prompt or PC.<br>

   Note: if you can't see System Variables, you can open "Git Bash"-> Navigate to desired folder-> git clone https://github.com/integration-nlbdigit/observability.git

6. <b>Install .NET SDK</b><br>
    https://aka.ms/dotnet/download
    ---Download .NET For Windows: https://dotnet.microsoft.com/en-us/download

7. <b>Install extensions in Visual Studio Code</b><br>
    •	C# Dev Kit (for .NET development)<br>
    •	REST Client (for API testing)<br>
    •	Docker <br>

8. <b>Install Postman for API Testing</b><br>
    Postman is a popular tool for testing and interacting with APIs<br>
    Steps: Download Postman<br>
  
    What you should verify:<br>
    • You should be able to send API requests (GET, POST) to interact with the Spring Boot, .Net services etc.<br>   

<b>OPTIONAL</b>
1. <b> Install Java Development Kit (JDK)</b>
  Java 11 or higher is required for building and running the Spring Boot microservices. Steps:<br>
  • Install JDK (Java 11 or higher): <br>
  • Download JDK 11+ TBD LINK: https://www.oracle.com/java/technologies/downloads/#java11?er=221886
   
    • Verify Installation: <br>
    • Run java -version in the terminal to check the installed Java version.
     
    What you should verify:<br>
    • Make sure Java is installed correctly and the version is 11 or above.

2. <b>Install Maven</b><br>
   •	Download and Install Maven<br>
      Go to the official Maven website: https://maven.apache.org/download.cgi<br>
      Download the binary ZIP (not the source).<br>
      Extract it to a location like C:\maven<br>

    •	Add Maven to System PATH <br>
      Now, add Maven to the Windows environment variable<br>
      Open Environment Variables:<br>
      o	Press Win + R, type sysdm.cpl, and hit Enter.<br>
      o	Go to the Advanced tab and click Environment Variables.<br>

    • Add MAVEN_HOME:<br>
      o	Under System Variables, click New.<br>
      o	Variable Name: MAVEN_HOME<br>
      o	Variable Value: C:\maven (or wherever you extracted Maven)<br>
      o	Click OK.<br>

    • Add Maven to PATH:<br>
      o	Find the Path variable under System Variables, and click Edit.<br>
      o	Click New and add: makefile Copy code C:\maven\bin<br>
      o	Click OK to save.<br>

   •	Verify the Installation<br>
      Close and reopen Command Prompt or PowerShell, then run:<br>
      mvn -version<br>

      You should see output like:<br>
      Apache Maven 3.x.xMaven home: C:\mavenJava version: 17.0.x<br>
      If you see this, Maven is successfully installed! 🚀<br>

3. <b>Install Integrated Development Environment (IDE)</b><br>
    A IDE will help you to write and debug Java code more efficiently.<br>
    Recommended IDE:<br>
    • IntelliJ IDEA: Preferred IDE for Java development. <br>
    • Download IntelliJ IDEA: https://www.jetbrains.com/idea/download/?section=windows <br>
     
    What you should verify:
    • The IDE is set up for Java development.<br>
    • Make sure you can open and edit Java files.<br>









      



