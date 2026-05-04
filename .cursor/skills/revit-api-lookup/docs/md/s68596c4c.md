---
kind: property
id: P:Autodesk.Revit.DB.Categories.Item(Autodesk.Revit.DB.BuiltInCategory)
source: html/562ddcba-8f15-7421-e7a5-6968ccef7b10.htm
---
# Autodesk.Revit.DB.Categories.Item Property

Retrieves a category object corresponding to a BuiltInCategory id.

## Syntax (C#)
```csharp
public virtual Category this[
	BuiltInCategory categoryId
] { get; }
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.BuiltInCategory`)

## Remarks
Unlike the method that obtains categories by name, this routine will obtain
the handle even of built-in subcategories.
Since 2016 it is advised to use either [!:​Autodesk::​Revit::DB::​Category::​GetCategory(​Document,​BuiltIn​Category)] 
or [!:​Autodesk::​Revit::DB::​Category::​GetCategory(​Document,​ElementId)] ​ method from Category class.

