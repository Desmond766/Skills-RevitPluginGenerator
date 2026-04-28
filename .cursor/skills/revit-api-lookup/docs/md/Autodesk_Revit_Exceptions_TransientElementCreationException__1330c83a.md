---
kind: type
id: T:Autodesk.Revit.Exceptions.TransientElementCreationException
source: html/5d572105-6feb-10ad-db16-4d09de36de2e.htm
---
# Autodesk.Revit.Exceptions.TransientElementCreationException

The exception that is thrown when TransientElementCreationScope is used incorrectly.

## Syntax (C#)
```csharp
[SerializableAttribute]
public class TransientElementCreationException : InvalidOperationException
```

## Remarks
The exception would be thrown in the following cases:
 An element that does not support TransientElementCreationScope is being created in the Scope. A TransientElementCreationScope is being created while another such scope is already active.

