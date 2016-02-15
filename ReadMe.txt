Instructions to Run the application:
1. Use the File "MitchellClaimDataModel.sql" to create the Database and Respective Tables
2. Folder "MitchellClaimService" contains solution of the WebService that provides the CRUD operations
3. Open IIS
4. Create Virtual Directory named "MitchellService"
5. Map the physical path of the Virtual Directory to "~\MitchellClaimService\MitchellClaimsHost" MitchellClaimService Folder
6. Explore the virtual directory in IIS and browse MitchellService.svc file to get the WSDL document of the webservice
7. Folder "MitchellClaimClient" contains solution of the Client for the WebService\
8. Run the client application to explore the CRUD features of the web service
