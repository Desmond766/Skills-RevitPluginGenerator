---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalNodeData.GetAnalyticalNodeData(Autodesk.Revit.DB.Element)
source: html/ad0f2a8f-15cf-fae3-790d-a17e0d8ff6b1.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalNodeData.GetAnalyticalNodeData Method

Returns AnalyticalNodeData associated with this element, if it exists.

## Syntax (C#)
```csharp
public static AnalyticalNodeData GetAnalyticalNodeData(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element from which we try to obtain AnalyticalNodeData.

## Remarks
If the input element doesn't have AnalyticalNodeData than it retuns Nothing nullptr a null reference ( Nothing in Visual Basic) .
 The input element should be a ReferencePoint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

