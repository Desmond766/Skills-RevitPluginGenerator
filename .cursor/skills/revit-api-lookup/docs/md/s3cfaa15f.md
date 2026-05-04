---
kind: method
id: M:Autodesk.Revit.DB.KeynoteEntry.#ctor(System.String,System.String)
source: html/c33467f2-a7d9-d8b7-ff34-71a0120cd903.htm
---
# Autodesk.Revit.DB.KeynoteEntry.#ctor Method

Constructs a new KeynoteEntry from the given
 key name and keynote text. KeynoteEntry objects
 created from this constructor will not have parents.

## Syntax (C#)
```csharp
public KeynoteEntry(
	string key,
	string text
)
```

## Parameters
- **key** (`System.String`) - The key of this KeynoteEntry
- **text** (`System.String`) - The text associated with this KeynoteEntry

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - key is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

