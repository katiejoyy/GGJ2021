public interface DebugNotifier
{
	void SubscribeToDebugNotifications(DebugListener listener);
	void UnsubscribeFromDebugNotifications(DebugListener listener);
}
