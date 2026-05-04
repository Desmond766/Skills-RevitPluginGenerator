---
kind: property
id: P:Autodesk.Revit.DB.TextElement.Text
source: html/1d4b2991-02ba-07d7-0c25-14f2f62f72a6.htm
---
# Autodesk.Revit.DB.TextElement.Text Property

The content of the element as a plain string stripped of all formating.

## Syntax (C#)
```csharp
public string Text { get; set; }
```

## Remarks
If a new text content is set, all previous formating that might have been
 set on parts of the original text will be lost. After setting the new text,
 only the formating parameters of the associated text type will be applied. The value of this property can also be accessed via the TEXT_TEXT
 Built-In parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

