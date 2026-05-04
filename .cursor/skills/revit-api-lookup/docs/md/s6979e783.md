---
kind: method
id: M:Autodesk.Revit.DB.Document.LoadFamily(Autodesk.Revit.DB.Document)
zh: 文档、文件
source: html/6a91dc8e-6c2b-52b9-dfc4-d56fa472852b.htm
---
# Autodesk.Revit.DB.Document.LoadFamily Method

**中文**: 文档、文件

Loads the contents of this family document into another document.

## Syntax (C#)
```csharp
public Family LoadFamily(
	Document targetDocument
)
```

## Parameters
- **targetDocument** (`Autodesk.Revit.DB.Document`) - The target document where the family will be loaded.

## Returns
Reference of the family in the target document.

## Remarks
If you are reloading an edited family back into the source document from which it was extracted, this method will always fail.
This is because this method automatically suppresses the prompts Revit typically uses to deal with conflicts between families, and 
assumes that any such conflict should prevent the loading. If you want to be able to reload the same family into the source document,
you should use the LoadFamily() overload accepting IFamilyLoadOptions .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"targetDocument"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current document is not a family document,
or when the target document is modifiable (e.g. there is an uncommitted transaction) or doesn't support load of this kind of families (e.g. loading a model family to detail family is disallowed),
or when this family was found in the target document already and the conflict caused an automatic abort of the load operation,
or when a shared family in this family was found in the target document already 
and the conflict caused an automatic abort of the load operation,
or this document is currently in a read-only state.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

