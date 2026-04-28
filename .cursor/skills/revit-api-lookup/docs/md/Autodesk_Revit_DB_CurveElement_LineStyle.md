---
kind: property
id: P:Autodesk.Revit.DB.CurveElement.LineStyle
source: html/691e64a2-e5ea-b619-4362-1a2c17e23b2f.htm
---
# Autodesk.Revit.DB.CurveElement.LineStyle Property

The line style of this curve element.

## Syntax (C#)
```csharp
public Element LineStyle { get; set; }
```

## Remarks
The return of this property will be a [!:Autodesk::Revit::DB::GraphicsStyle] element.
These graphics styles should be associated to subcategories of the BuiltInCategory OST_Lines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration failed. -- or --
Thrown when fail to get line style.

