---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.SetLayoutAsCustomPattern(System.Double,System.Double,System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.FabricWireItem},System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.FabricWireItem})
source: html/1544f3ff-e03d-7f32-a1d5-9a51ce7e47e0.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.SetLayoutAsCustomPattern Method

Sets the minor and major layout patterns as Custom, while specifying the needed parameters for this pattern.

## Syntax (C#)
```csharp
public void SetLayoutAsCustomPattern(
	double minorStartOverhang,
	double majorStartOverhang,
	IList<FabricWireItem> minorFabricWireItems,
	IList<FabricWireItem> majorFabricWireItems
)
```

## Parameters
- **minorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the minor direction.
- **majorStartOverhang** (`System.Double`) - The distance from the edge of the sheet to the first wire in the major direction.
- **minorFabricWireItems** (`System.Collections.Generic.IList < FabricWireItem >`) - The fabric wire items in the minor direction.
- **majorFabricWireItems** (`System.Collections.Generic.IList < FabricWireItem >`) - The fabric wire items in the major direction.

## Remarks
The following properties are not used for custom fabric sheet type:
 - MajorDirectionWireType;
 - MinorDirectionWireType;
 - MajorSpacing;
 - MinorSpacing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for minorStartOverhang is not a number
 -or-
 The given value for majorStartOverhang is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for minorStartOverhang must be between 0 and 30000 feet.
 -or-
 The given value for majorStartOverhang must be between 0 and 30000 feet.

