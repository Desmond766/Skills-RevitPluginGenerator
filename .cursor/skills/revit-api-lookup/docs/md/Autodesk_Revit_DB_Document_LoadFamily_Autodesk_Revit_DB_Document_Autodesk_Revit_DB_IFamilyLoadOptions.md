---
kind: method
id: M:Autodesk.Revit.DB.Document.LoadFamily(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.IFamilyLoadOptions)
zh: 文档、文件
source: html/cb950c8e-f440-c6db-8563-d1dd16ef3fee.htm
---
# Autodesk.Revit.DB.Document.LoadFamily Method

**中文**: 文档、文件

Loads the contents of this family document into another document.

## Syntax (C#)
```csharp
public Family LoadFamily(
	Document targetDocument,
	IFamilyLoadOptions familyLoadOptions
)
```

## Parameters
- **targetDocument** (`Autodesk.Revit.DB.Document`) - The target document which the family will be loaded into.
- **familyLoadOptions** (`Autodesk.Revit.DB.IFamilyLoadOptions`) - The interface implementation to use when responding to conflicts during the load operation.

## Returns
Reference of the family in the target document.

## Remarks
If you are reloading an edited family back into the source document from which it was extracted, use this overload.
This is because this overload allows you to respond to possible conflicts due to families already being present in the target document.
The Revit API offers one automatic overload: RevitUIFamilyLoadOptions, which will show the same prompts to the user as seen during an 
interactive load.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"targetDocument" or "familyLoadOptions"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current document is not a family document,
or when the target document is modifiable (e.g. there is an uncommitted transaction) or doesn't support load of this kind of families (e.g. loading a model family to detail family is disallowed),
or the load was cancelled due to a conflict and a False return from one of the interface methods,
or this document is currently in a read-only state.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

