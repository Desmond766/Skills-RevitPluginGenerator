---
kind: property
id: P:Autodesk.Revit.DB.TextElement.UpDirection
source: html/76e43206-5f28-5e64-e087-46c575327956.htm
---
# Autodesk.Revit.DB.TextElement.UpDirection Property

Direction along the vertical axis of letters of the text note.

## Syntax (C#)
```csharp
public XYZ UpDirection { get; }
```

## Remarks
This vector points up from the base of the letters
 and is always perpendicular to the base direction.
 Those two vectors together define the plane of the text.

