---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.AddReferences(System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
zh: 标记、打标、标签
source: html/333fc505-2f6b-e754-6841-fb7f7639284e.htm
---
# Autodesk.Revit.DB.IndependentTag.AddReferences Method

**中文**: 标记、打标、标签

Adds the provided list of references to the tag's list of references.

## Syntax (C#)
```csharp
public void AddReferences(
	IList<Reference> referencesToTag
)
```

## Parameters
- **referencesToTag** (`System.Collections.Generic.IList < Reference >`) - References to be tagged.

## Remarks
The references must pass the following requirements to be added:
 Must not be already tagged. Must be of the same category when TagMode is TM_ADDBY_CATEGORY. Must be taggable by this tag type. 
 If any of the above rules is not fulfilled, the execution will be stopped and an exception will be thrown

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The operation failed. Please verify that the references are all taggable and that they are not already tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.
 -or-
 This type of tag does not support multiple references.

