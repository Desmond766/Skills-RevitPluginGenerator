---
kind: property
id: P:Autodesk.Revit.DB.TextNoteOptions.TypeId
source: html/4eef8585-be67-b6af-7d32-885fd49511da.htm
---
# Autodesk.Revit.DB.TextNoteOptions.TypeId Property

Id of a text type that defines the style of a text note.

## Syntax (C#)
```csharp
public ElementId TypeId { get; set; }
```

## Remarks
No default value. A valid type element Id must be set prior using the options.
 The text type allows its font name parameter to be set to a font unavailable on the current system.
 However, any text note created with or set to this font type will be displayed in a default substituted font (e.g. Arial)
 and the UI will show a blank value in the text type font name parameter.
 Once the document is opened on a system which has the font set on the text type,
 the text note will display with that font and the UI will show that font in the text type font name parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

