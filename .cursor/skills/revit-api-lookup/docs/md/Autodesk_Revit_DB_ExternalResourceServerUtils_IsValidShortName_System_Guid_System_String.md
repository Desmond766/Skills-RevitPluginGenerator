---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceServerUtils.IsValidShortName(System.Guid,System.String)
source: html/5d7f45ca-6e12-0979-2e6c-e6959e1617de.htm
---
# Autodesk.Revit.DB.ExternalResourceServerUtils.IsValidShortName Method

Checks whether the name is a valid short name for the external resource server.

## Syntax (C#)
```csharp
public static bool IsValidShortName(
	Guid serverId,
	string serverName
)
```

## Parameters
- **serverId** (`System.Guid`) - The id of the external resource server.
- **serverName** (`System.String`) - The short name of the external resource server.

## Returns
True if the name is a valid short name, false otherwise.

## Remarks
A valid short name should match the restrictions documented in GetShortName () () () .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

