---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.PlaceInHost(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Transform)
source: html/f1eb07fb-91a6-6ca9-f763-44f29e34014d.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.PlaceInHost Method

Inserts the single Fabric Sheet instance into the host element.

## Syntax (C#)
```csharp
public void PlaceInHost(
	Element hostElement,
	Transform transform
)
```

## Parameters
- **hostElement** (`Autodesk.Revit.DB.Element`) - A structural element that will host the Fabric Sheet. The element must support fabric hosting.
- **transform** (`Autodesk.Revit.DB.Transform`) - The transform that defines the placement of the instance single Fabric Sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The host Element is not a valid host for Fabric Sheet.
 -or-
 transform defines the placement out of the host.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - transform is not conformal.

