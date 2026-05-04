---
kind: method
id: M:Autodesk.Revit.UI.IExternalApplication.OnShutdown(Autodesk.Revit.UI.UIControlledApplication)
source: html/5169052b-c8ba-cf0f-4d4b-a7cd69d5866b.htm
---
# Autodesk.Revit.UI.IExternalApplication.OnShutdown Method

Implement this method to execute some tasks when Autodesk Revit shuts down.

## Syntax (C#)
```csharp
Result OnShutdown(
	UIControlledApplication application
)
```

## Parameters
- **application** (`Autodesk.Revit.UI.UIControlledApplication`) - A handle to the application being shut down.

## Returns
Indicates if the external application completes its work successfully.

