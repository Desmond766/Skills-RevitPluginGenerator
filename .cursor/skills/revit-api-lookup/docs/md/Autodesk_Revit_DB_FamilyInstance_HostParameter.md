---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.HostParameter
zh: 族实例
source: html/bcf1a885-5015-0b87-dfe8-9109d499f4e7.htm
---
# Autodesk.Revit.DB.FamilyInstance.HostParameter Property

**中文**: 族实例

If the instance is hosted by a wall, this property returns the parameter value of the insertion
point of the instance along the wall's location curve, as long as the family of the instance isn't work plane based.

## Syntax (C#)
```csharp
public double HostParameter { get; }
```

## Remarks
This works for instances with a host element that is of type Wall or is in the OST_Walls category only, 
including in-place ones.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Only hosted instances whose family is not work plane based can support this functionality.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Only hosted instances of type Wall or in-place elements of category OST_Walls can support this functionality.

