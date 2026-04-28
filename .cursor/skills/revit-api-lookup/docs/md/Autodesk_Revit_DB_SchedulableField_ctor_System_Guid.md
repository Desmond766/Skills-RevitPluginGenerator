---
kind: method
id: M:Autodesk.Revit.DB.SchedulableField.#ctor(System.Guid)
source: html/a1fa158c-e1da-1e29-6df1-8722ef0633b6.htm
---
# Autodesk.Revit.DB.SchedulableField.#ctor Method

Creates a new SchedulableField.

## Syntax (C#)
```csharp
public SchedulableField(
	Guid customFieldId
)
```

## Parameters
- **customFieldId** (`System.Guid`) - The Guid that identifies the custom field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The provided guid doens't represent a valid custom field.

