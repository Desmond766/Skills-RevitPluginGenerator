---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilderResult.GetIssuesForFaceSet(System.Int32)
source: html/9063460c-2dd8-a00e-6519-8733117870cb.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilderResult.GetIssuesForFaceSet Method

Returns the array of issues encountered while processing
 a face set with index 'setIndex'.

## Syntax (C#)
```csharp
public IList<TessellatedBuildIssue> GetIssuesForFaceSet(
	int setIndex
)
```

## Parameters
- **setIndex** (`System.Int32`) - Index of the face set.

## Returns
Array of issues encountered while processing a face set
 with index 'setIndex'.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - 'SetIndex' is a valid face set index for the results stored in 'this'.

