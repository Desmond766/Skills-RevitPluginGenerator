---
kind: method
id: M:Autodesk.Revit.DB.TextNoteOptions.#ctor(Autodesk.Revit.DB.ElementId)
source: html/ddb0b7f2-c385-ce70-f2df-92ae90ea9a92.htm
---
# Autodesk.Revit.DB.TextNoteOptions.#ctor Method

Constructs text options to create text of the given type.

## Syntax (C#)
```csharp
public TextNoteOptions(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Id of a text type that defines the style of a text note.

## Remarks
Except for the TypeId, all other properties of the option class will be populated with their respective default values.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

