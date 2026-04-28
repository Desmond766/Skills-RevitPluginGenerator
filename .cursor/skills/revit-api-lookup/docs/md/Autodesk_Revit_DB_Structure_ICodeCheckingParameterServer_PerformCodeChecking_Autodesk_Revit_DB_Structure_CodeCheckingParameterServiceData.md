---
kind: method
id: M:Autodesk.Revit.DB.Structure.ICodeCheckingParameterServer.PerformCodeChecking(Autodesk.Revit.DB.Structure.CodeCheckingParameterServiceData)
source: html/6d0281c1-2fe6-686b-2d59-13a840785e95.htm
---
# Autodesk.Revit.DB.Structure.ICodeCheckingParameterServer.PerformCodeChecking Method

The server's method that will be called when Revit User clicks the Code Checking parameter's button from the properties palette.

## Syntax (C#)
```csharp
bool PerformCodeChecking(
	CodeCheckingParameterServiceData data
)
```

## Parameters
- **data** (`Autodesk.Revit.DB.Structure.CodeCheckingParameterServiceData`) - The Code Checking data.

## Returns
Indicates whether the code checking parameter server is executed successfully.

## Remarks
The server provides UI way for Revit user to view and modify the detail data corresponding with the parameter value.
 The server may also modify the code checking parameter value itself during the execution.
 The method should always return 'true' if the server is successfully executed, no matter whether the server changes anything.
 Return 'false' or if the server throws, indicates a failed case, all changes made by the server will be discarded.
 A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service, see ExternalServiceRegistry . Assign server to code checking instance.

