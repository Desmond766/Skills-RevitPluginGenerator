---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.GetResult
source: html/b1cb34d1-a485-8926-f437-23edb67cdc32.htm
---
# Autodesk.Revit.DB.BRepBuilder.GetResult Method

Get the Geometry object built by this BRepBuilder. This will clear the built Geometry stored in the BRepBuilder.
 This function will throw if this BRepBuilder hasn't completed building the b-rep. Use IsResultAvailable() to verify that this BRepBuilder contains a valid result.

## Syntax (C#)
```csharp
public Solid GetResult()
```

## Returns
The Geometry object built by this BRepBuilder.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object hasn't completed building data or was unsuccessful building it. Built Geometry is unavailable.
 In order to access the built Geometry, Finish() must be called first. That will set the state to completed.

