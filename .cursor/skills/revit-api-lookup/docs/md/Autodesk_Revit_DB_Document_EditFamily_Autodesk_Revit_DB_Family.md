---
kind: method
id: M:Autodesk.Revit.DB.Document.EditFamily(Autodesk.Revit.DB.Family)
zh: 文档、文件
source: html/56e636ee-5008-0ee5-9d6c-5f622dedfbcb.htm
---
# Autodesk.Revit.DB.Document.EditFamily Method

**中文**: 文档、文件

Gets the document of a loaded family to edit.

## Syntax (C#)
```csharp
public Document EditFamily(
	Family loadedFamily
)
```

## Parameters
- **loadedFamily** (`Autodesk.Revit.DB.Family`) - The loaded family in current document.

## Returns
Reference of the document of the family.

## Remarks
This creates an independent copy of the family for editing. 
To apply the changes back to the family stored in the document, use the LoadFamily overload 
accepting IFamilyLoadOptions .
 This method may not be called if the document is currently modifiable (has an open transaction)
or is in a read-only state. The method may not be called during dynamic updates. To test the 
document's current status, check the values of IsModifiable and IsReadOnly properties.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"loadedFamily"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"loadedFamily"-is an in-place family or a non-editable family. 
(This can be checked with the IsInPlace and IsEditable properties of the Family class.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family is already being edited.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this method is called while the document is modifiable (i.e. it has an unfinished transaction.)
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this method is currently in a read-only state.

