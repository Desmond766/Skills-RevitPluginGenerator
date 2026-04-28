---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilder.AreTargetAndFallbackCompatible(Autodesk.Revit.DB.TessellatedShapeBuilderTarget,Autodesk.Revit.DB.TessellatedShapeBuilderFallback)
source: html/fc565805-bda1-2cd3-6bf0-e0defa4edfc9.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder.AreTargetAndFallbackCompatible Method

Checks whether this combination of fallback and target parameters
 can be used as a valid combination of inputs.

## Syntax (C#)
```csharp
public bool AreTargetAndFallbackCompatible(
	TessellatedShapeBuilderTarget target,
	TessellatedShapeBuilderFallback fallback
)
```

## Parameters
- **target** (`Autodesk.Revit.DB.TessellatedShapeBuilderTarget`) - What kind of geometrical objects should be built.
- **fallback** (`Autodesk.Revit.DB.TessellatedShapeBuilderFallback`) - What should be done if a geometrical object described by 'target'
 parameter cannot be built using all data from all stored face sets.

## Returns
True if the combination of fallback and target are a valid combination, false
 otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

