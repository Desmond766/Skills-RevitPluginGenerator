---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.GetAreaBasedLoadBoundaryLineData
source: html/a99e772c-9f79-c81f-14ec-71703e19676e.htm
---
# Autodesk.Revit.DB.CurveElement.GetAreaBasedLoadBoundaryLineData Method

Gets the area based load boundary line data from this curve, if applicable.

## Syntax (C#)
```csharp
public AreaBasedLoadBoundaryLineData GetAreaBasedLoadBoundaryLineData()
```

## Returns
The area based load boundary line data, if this is an area based load boundary,
 or Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Remarks
Will return Nothing nullptr a null reference ( Nothing in Visual Basic) if curve element isn't an area based load boundary line.

