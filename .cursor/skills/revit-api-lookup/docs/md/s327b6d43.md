---
kind: method
id: M:Autodesk.Revit.DB.IExternalDBApplication.OnStartup(Autodesk.Revit.ApplicationServices.ControlledApplication)
source: html/8407ff9d-8598-b5dc-d031-4a9512f67e4f.htm
---
# Autodesk.Revit.DB.IExternalDBApplication.OnStartup Method

Implement this method to execute some tasks when Autodesk Revit starts.

## Syntax (C#)
```csharp
ExternalDBApplicationResult OnStartup(
	ControlledApplication application
)
```

## Parameters
- **application** (`Autodesk.Revit.ApplicationServices.ControlledApplication`) - Handle to the Revit Application object.

## Returns
Indicates if the external db application completes its work successfully.

## Remarks
Typically, event handlers and updaters are registered in this method.

