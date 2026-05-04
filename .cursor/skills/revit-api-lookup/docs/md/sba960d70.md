---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricWireItem.Create(System.Double,System.Double,Autodesk.Revit.DB.ElementId,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/f75a5a73-4e2d-fec1-be3c-e3b3b227e326.htm
---
# Autodesk.Revit.DB.Structure.FabricWireItem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a single Fabric wire.

## Syntax (C#)
```csharp
public static FabricWireItem Create(
	double distance,
	double wireLength,
	ElementId wireType,
	double wireOffset
)
```

## Parameters
- **distance** (`System.Double`) - The distance between this wire and the next wire in the Custom Fabric Sheet
- **wireLength** (`System.Double`) - Length of this wire
- **wireType** (`Autodesk.Revit.DB.ElementId`) - The wire type of this wire
- **wireOffset** (`System.Double`) - The offset between two wires in the same line

## Returns
The newly created Fabric wire instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for distance is not a number
 -or-
 The given value for wireLength is not a number
 -or-
 wireType is not a valid Element identifier.
 -or-
 The given value for wireOffset is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for distance must be between 0 and 30000 feet.
 -or-
 The given value for wireLength must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for wireOffset must be between 0 and 30000 feet.

