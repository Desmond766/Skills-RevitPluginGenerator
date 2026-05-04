---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.RemoveReferences(System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
zh: 标记、打标、标签
source: html/902f7f27-964e-d7cd-e582-07f45750d768.htm
---
# Autodesk.Revit.DB.IndependentTag.RemoveReferences Method

**中文**: 标记、打标、标签

Removes the provided list of references from the tag's list of references.

## Syntax (C#)
```csharp
public void RemoveReferences(
	IList<Reference> referencesToRemove
)
```

## Parameters
- **referencesToRemove** (`System.Collections.Generic.IList < Reference >`) - References to be removed from tag.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The operation failed. Please verify that the references are all tagged before removing them.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

