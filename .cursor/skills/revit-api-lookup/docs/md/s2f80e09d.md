---
kind: method
id: M:Autodesk.Revit.DB.ClassificationEntry.#ctor(System.String,System.String,System.String,System.Int32,Autodesk.Revit.DB.ElementId)
source: html/54aea4a8-c569-8667-7816-d9d8a2c93abd.htm
---
# Autodesk.Revit.DB.ClassificationEntry.#ctor Method

Constructs a ClassificationEntry object

## Syntax (C#)
```csharp
public ClassificationEntry(
	string key,
	string parentKey,
	string description,
	int level,
	ElementId categoryId
)
```

## Parameters
- **key** (`System.String`) - The key of this ClassificationEntry.
- **parentKey** (`System.String`) - The parent key of this ClassificationEntry.
- **description** (`System.String`) - The description associated with this ClassificationEntry.
- **level** (`System.Int32`) - The level of this ClassficationEntry.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id of this ClassificationEntry.
 The category can be invalidElementId, otherwise it must represent Revit existing category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - key is an empty string.
 -or-
 The categoryId is not appropriate category id for classfication entry.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

