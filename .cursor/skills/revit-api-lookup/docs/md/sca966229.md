---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.SetGlobal3DDirectionHandles(System.Boolean,Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/003adb28-a381-05f5-6490-e80ecc13b4fe.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.SetGlobal3DDirectionHandles Method

Sets the handles representing the cardinal directions in 3D.

## Syntax (C#)
```csharp
public static void SetGlobal3DDirectionHandles(
	bool positive,
	IFCAnyHandle xDir,
	IFCAnyHandle yDir,
	IFCAnyHandle zDir
)
```

## Parameters
- **positive** (`System.Boolean`) - True if the handles returned should be in the positive direction, false
 if the handles should be in the negative direction.
- **xDir** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The X direction handle.
- **yDir** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The Y direction handle.
- **zDir** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The Z direction handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

