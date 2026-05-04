---
kind: enumMember
id: F:Autodesk.Revit.DB.ExternalService.ExecutionPolicy.FirstApplicableServer
enum: Autodesk.Revit.DB.ExternalService.ExecutionPolicy
source: html/5234000e-cf74-d7aa-85ff-dcfbed63434b.htm
---
# Autodesk.Revit.DB.ExternalService.ExecutionPolicy.FirstApplicableServer

This policy instructs to find the first applicable server,
 which would be the first one that the service claims (by
 returning True from the CanExecute method) it can be executed.
 With that server the service will be called to execute it.
 If the execution fails or if an unhandled exception is raised
 from it the result will be ExternalServiceResult.Failed, otherwise
 it will be ExternalServiceResult.Succeeded, unless no applicable
 server can be found, which would cause returning ExternalServiceResult.Unhandled.

