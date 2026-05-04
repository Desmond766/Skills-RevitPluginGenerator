---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.SetGlobal2DDirectionHandles(System.Boolean,Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/4ed80681-2dc6-14fa-e1cc-552ceba35aec.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.SetGlobal2DDirectionHandles Method

Sets the handles representing the cardinal directions in 2D.

## Syntax (C#)
```csharp
public static void SetGlobal2DDirectionHandles(
	bool positive,
	IFCAnyHandle xDir,
	IFCAnyHandle yDir
)
```

## Parameters
- **positive** (`System.Boolean`) - True if the handles returned should be in the positive direction, false
 if the handles should be in the negative direction.
- **xDir** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The X direction handle.
- **yDir** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The Y direction handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

