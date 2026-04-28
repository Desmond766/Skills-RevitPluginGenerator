---
kind: property
id: P:Autodesk.Revit.DB.Architecture.MultistoryStairs.ActualTreadDepth
source: html/736ed3f5-be03-a819-96b8-1cd302f3ae22.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.ActualTreadDepth Property

The actual depth of the stairs treads in the stairs, actual tread depth is equal to minimum tread depth by default.

## Syntax (C#)
```csharp
public double ActualTreadDepth { get; set; }
```

## Remarks
In a multistory stairs, all the stairs elements keep the same tread depth parameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for actualTreadDepth must be greater than 0 and no more than 30000 feet.

