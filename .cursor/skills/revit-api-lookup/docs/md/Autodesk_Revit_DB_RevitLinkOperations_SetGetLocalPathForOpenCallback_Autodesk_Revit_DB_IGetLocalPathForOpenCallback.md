---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkOperations.SetGetLocalPathForOpenCallback(Autodesk.Revit.DB.IGetLocalPathForOpenCallback)
source: html/f113b16f-7b77-696a-d263-293f35c2c993.htm
---
# Autodesk.Revit.DB.RevitLinkOperations.SetGetLocalPathForOpenCallback Method

Sets the IGetLocalPathForOpenCallback that will support the "Open (and Unload)" command for Revit links
 obtained from an IExternalResourceServer.

## Syntax (C#)
```csharp
public void SetGetLocalPathForOpenCallback(
	IGetLocalPathForOpenCallback makeLocalCopyForOpen
)
```

## Parameters
- **makeLocalCopyForOpen** (`Autodesk.Revit.DB.IGetLocalPathForOpenCallback`) - The IGetLocalPathForOpenCallback that will support the "Open (and Unload)" command.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

