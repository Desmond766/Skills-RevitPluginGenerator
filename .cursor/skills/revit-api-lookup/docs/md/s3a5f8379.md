---
kind: type
id: T:Autodesk.Revit.DB.Category
source: html/d390ecf6-e5db-d7c1-d7f2-766c0686e975.htm
---
# Autodesk.Revit.DB.Category

Represents the category or subcategory to which an element belongs.

## Syntax (C#)
```csharp
public class Category : APIObject
```

## Remarks
Categories are an important tool within Revit for identifying the inferred type of an
element, such as anything in the Walls category should be considered as a wall. The API
exposes access to the built in categories within Revit via the Document.Settings.Categories
property.

