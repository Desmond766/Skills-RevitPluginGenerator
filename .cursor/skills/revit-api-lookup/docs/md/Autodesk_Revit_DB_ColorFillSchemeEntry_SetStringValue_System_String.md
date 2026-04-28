---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.SetStringValue(System.String)
source: html/2bcd9bfc-dff4-9619-f794-f939d284a425.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.SetStringValue Method

Sets new String value of entry.

## Syntax (C#)
```csharp
public void SetStringValue(
	string value
)
```

## Parameters
- **value** (`System.String`)

## Remarks
This method should only be used if the StorageType property reports the type of the entry as a String.
 New value should be not empty and valid for Revit name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The entry has different storage type with String, or the value is empty, or contains forbidden characters.

