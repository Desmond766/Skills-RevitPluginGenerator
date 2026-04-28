---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.GetSubelementOnLevel(Autodesk.Revit.DB.ElementId)
zh: 栏杆
source: html/b9d35dc7-42d9-1699-4985-bc80fe2c7045.htm
---
# Autodesk.Revit.DB.Architecture.Railing.GetSubelementOnLevel Method

**中文**: 栏杆

Gets the subelement on given level.

## Syntax (C#)
```csharp
public Subelement GetSubelementOnLevel(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the level the railing subelement is placed on.

## Returns
The subelement in given level.
 Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if railing has no subelements on given level.

## Remarks
The method is valid only for railings hosted by stairs in MultistoryStairs .
 Input level should be a level of the railing stairs.
 See getStairsPlacementLevels method of MultistoryStairs .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The railing is not hosted by stairs in MultistoryStairs .

