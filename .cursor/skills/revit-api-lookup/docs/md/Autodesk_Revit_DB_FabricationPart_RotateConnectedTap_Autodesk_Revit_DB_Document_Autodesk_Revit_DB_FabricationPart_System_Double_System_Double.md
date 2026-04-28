---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.RotateConnectedTap(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationPart,System.Double,System.Double)
source: html/1a5cd3ae-ee5e-ee99-961a-89a0f4d59c3b.htm
---
# Autodesk.Revit.DB.FabricationPart.RotateConnectedTap Method

Rotates a connected fabrication tap by the specified angles about the primary and secondary axis.

## Syntax (C#)
```csharp
public static void RotateConnectedTap(
	Document document,
	FabricationPart tap,
	double primaryAxisRotateBy,
	double secondaryAxisRotateBy
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **tap** (`Autodesk.Revit.DB.FabricationPart`) - The connected fabrication part tap to rotate.
- **primaryAxisRotateBy** (`System.Double`) - The primary axis rotation angle in radians to rotate by.
- **secondaryAxisRotateBy** (`System.Double`) - The secondary axis rotation angle in radians to rotate by.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Is not connected as a fabrication part tap.
 -or-
 tap cannot be rotated about the primary axis by the specified angle: primaryAxisRotateBy
 -or-
 tap cannot be rotated about the secondary axis by the specified angle: secondaryAxisRotateBy
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

