---
kind: method
id: M:Autodesk.Revit.DB.PartMaker.IsSourceElement(Autodesk.Revit.DB.ElementId)
source: html/d4df49f1-4cfb-8104-c557-af0f64e60af3.htm
---
# Autodesk.Revit.DB.PartMaker.IsSourceElement Method

Is the element a source for this PartMaker

## Syntax (C#)
```csharp
public bool IsSourceElement(
	ElementId elemId
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`)

## Returns
Returns true if elemId is among the source elements of this PartMaker

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

