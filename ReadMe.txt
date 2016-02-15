Instructions to Run the application:
1. Use the File "MitchellClaimDataModel.sql" to create the Database and Respective Tables
2. Extract the "MitchellClaimService.zip" for solution of the WebService that provides the CRUD operations
3. Open IIS
4. Create Virtual Directory named "MitcellService"
5. Map the physical path of the Virtudla Directory to "~\MitchellClaimService\MitchellClaimsHost" in the extracted zip file
6. Explore the virtual directory in IIS and browse MitcellService.svc file to get the WSDL document of the webservice
7. Extract the "MitchellClaimClient.zip" for solution of the Client for the WebService\
8. Run the client application to explore the CRUD features of the web service