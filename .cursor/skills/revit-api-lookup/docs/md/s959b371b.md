---
kind: method
id: M:Autodesk.Revit.DB.KeynoteEntry.#ctor(System.String,System.String,System.String)
source: html/f9605318-c280-924f-f59f-274d581a5b8e.htm
---
# Autodesk.Revit.DB.KeynoteEntry.#ctor Method

Constructs a new KeynoteEntry from the given
 key name, parent key name, and keynote text.

## Syntax (C#)
```csharp
public KeynoteEntry(
	string key,
	string parentKey,
	string text
)
```

## Parameters
- **key** (`System.String`) - The key of this KeynoteEntry.
- **parentKey** (`System.String`) - The parent key of this KeynoteEntry.
 Empty string means this KeynoteEntry does not have a parent.
- **text** (`System.String`) - The text associated with this KeynoteEntry

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - key is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

