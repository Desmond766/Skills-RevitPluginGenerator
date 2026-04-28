---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.IsValidPartitionName(System.String,System.String@)
source: html/a250660a-5dcb-47a6-1960-e3750fd4df8a.htm
---
# Autodesk.Revit.DB.NumberingSchema.IsValidPartitionName Method

Tests if the given string can be used as a name for a numbering partition.

## Syntax (C#)
```csharp
public static bool IsValidPartitionName(
	string name,
	out string message
)
```

## Parameters
- **name** (`System.String`) - A name to validate.
- **message** (`System.String %`) - Optional string to receive an error message to possibly show to the
 end user in case the name is found invalid. This argument may be null.

## Returns
Returns True if the name can be used; or False if the string contains invalid characters.

## Remarks
For a name to be considered valid it must contain only printable characters
 excluding any characters that may not be used in name of a file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

