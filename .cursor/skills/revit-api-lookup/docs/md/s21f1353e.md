---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.IsSameAs(Autodesk.Revit.DB.FabricationPart,System.Collections.Generic.IList{Autodesk.Revit.DB.Fabrication.FabricationPartCompareType})
source: html/c09da6fe-1f56-2bbc-74d2-8a8f451eda4a.htm
---
# Autodesk.Revit.DB.FabricationPart.IsSameAs Method

Compare this fabrication part with the part passed and checks the pattern dimensions and options. A list of fields that can be ignored in the comparison check can be specified.

## Syntax (C#)
```csharp
public bool IsSameAs(
	FabricationPart part,
	IList<FabricationPartCompareType> ignoreFields
)
```

## Parameters
- **part** (`Autodesk.Revit.DB.FabricationPart`) - The part to compare this part with.
- **ignoreFields** (`System.Collections.Generic.IList < FabricationPartCompareType >`) - Array of types of data to ignore from the comparison check.

## Returns
Returns true if the fabrication parts are the same.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

