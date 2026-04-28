---
kind: method
id: M:Autodesk.Revit.DB.IExternalDBApplication.OnShutdown(Autodesk.Revit.ApplicationServices.ControlledApplication)
source: html/4e14b914-d903-165f-e973-73490a986927.htm
---
# Autodesk.Revit.DB.IExternalDBApplication.OnShutdown Method

Implement this method to execute some tasks when Autodesk Revit shuts down.

## Syntax (C#)
```csharp
ExternalDBApplicationResult OnShutdown(
	ControlledApplication application
)
```

## Parameters
- **application** (`Autodesk.Revit.ApplicationServices.ControlledApplication`) - Handle to the Revit Application object.

## Returns
Indicates if the external db application completes its work successfully.

