---
kind: enumMember
id: F:Autodesk.Revit.DB.ExternalService.ExecutionPolicy.AllApplicableServers
enum: Autodesk.Revit.DB.ExternalService.ExecutionPolicy
source: html/5234000e-cf74-d7aa-85ff-dcfbed63434b.htm
---
# Autodesk.Revit.DB.ExternalService.ExecutionPolicy.AllApplicableServers

Under this policy the framework will call to execute a service with all
 applicable servers, that is the servers that are currently set as active
 and for which the service responds affirmatively to the CanExecute method.
 If and only if the service can execute all applicable servers successfully
 the execution returns ExternalServiceResult.Succeeded. If execution of
 any applicable server fails, the execution loop breaks and the return
 value will be ExternalServiceResult.Failed. If no applicable servers
 can be found, the return value will be ExternalServiceResult.Unhandled.

