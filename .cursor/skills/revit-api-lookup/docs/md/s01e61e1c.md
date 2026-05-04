---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetNodeByIndex(System.Int32)
source: html/9ebcaff8-b11a-e81a-3e95-eb30eff36c52.htm
---
# Autodesk.Revit.DB.Analysis.MEPAnalyticalModelData.GetNodeByIndex Method

Gets the specified analytical node.

## Syntax (C#)
```csharp
public MEPAnalyticalNode GetNodeByIndex(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The node index number by their storing sequence, starting from 0.

## Returns
The returned analytical node.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index must range from 0 to GetNumberOfNodes()-1.

