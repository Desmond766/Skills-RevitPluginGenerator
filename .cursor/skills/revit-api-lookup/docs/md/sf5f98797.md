---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.CanExecute(Autodesk.Revit.DB.View)
source: html/6400d421-2e01-74ec-4f73-62c91ef81a11.htm
---
# Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.CanExecute Method

Can be used to allow the server to execute only in certain views.

## Syntax (C#)
```csharp
bool CanExecute(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view where rendering will occur.

## Returns
True if the server can be executed in the provided view, false otherwise.

## Remarks
Execution of a DirectContext3D server means that the server is called upon to contribute a bounding box
 and graphics content (opaque and transparent) for an opened view. The following are some of the conditions
 that control whether the server is executed: The return value of this interface method. Whether the server is one of the active servers for the service. For servers that use DirectContext3D handles, the visibility of handle instances.

