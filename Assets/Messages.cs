using System;
using System.Collections.Generic;
using UnityEngine;
	
public class Message
{
	protected readonly Dictionary<string, Action> Channels = new Dictionary<string, Action>();
	
	protected Action action;
	
	public void Say()
	{
		if (action != null) action();
	}
	
	public virtual void Subscribe(Action callback)
	{
		action += callback;
	}
	
	public virtual void Unscribe(Action callback)
	{
		action -= callback;
	}
	
	public void Say(string channel)
	{
		Action ch;
		if (Channels.TryGetValue(channel, out ch))
			ch();
	}
	
	public virtual void Subscribe(string channel, Action callback)
	{
		Action ch;
		if (!Channels.TryGetValue(channel, out ch))
			Channels.Add(channel, callback);
		else
			ch += callback;
	}
	
	public virtual void Unscribe(string channel, Action callback)
	{
		Action ch;
		if (Channels.TryGetValue(channel, out ch))
			ch -= callback;
	}
}

public class Message<T0>
{
	protected readonly Dictionary<string, Action<T0>> Channels = new Dictionary<string, Action<T0>>();
	
	protected Action<T0> action;
	
	public void Say(T0 arg0)
	{
		if (action != null) action(arg0);
	}
	
	public virtual void Subscribe(Action<T0> callback)
	{
		action += callback;
	}
	
	public virtual void Unscribe(Action<T0> callback)
	{
		action -= callback;
	}
	
	public void Say(string channel, T0 arg0)
	{
		Action<T0> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch(arg0);
	}
	
	public virtual void Subscribe(string channel, Action<T0> callback)
	{
		Action<T0> ch;
		if (!Channels.TryGetValue(channel, out ch))
			Channels.Add(channel, callback);
		else
			ch += callback;
	}
	
	public virtual void Unscribe(string channel, Action<T0> callback)
	{
		Action<T0> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch -= callback;
	}
}

public class Message<T0, T1>
{
	protected readonly Dictionary<string, Action<T0, T1>> Channels = new Dictionary<string, Action<T0, T1>>();
	
	protected Action<T0, T1> action;
	
	public void Say(T0 arg0, T1 arg1)
	{
		if (action != null) action(arg0, arg1);
	}
	
	public virtual void Subscribe(Action<T0, T1> callback)
	{
		action += callback;
	}
	
	public virtual void Unscribe(Action<T0, T1> callback)
	{
		action -= callback;
	}
	
	public void Say(string channel, T0 arg0, T1 arg1)
	{
		Action<T0, T1> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch(arg0, arg1);
	}
	
	public virtual void Subscribe(string channel, Action<T0, T1> callback)
	{
		Action<T0, T1> ch;
		if (!Channels.TryGetValue(channel, out ch))
			Channels.Add(channel, callback);
		else
			ch += callback;
	}
	
	public virtual void Unscribe(string channel, Action<T0, T1> callback)
	{
		Action<T0, T1> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch -= callback;
	}
}

public class Message<T0, T1, T2>
{
	protected readonly Dictionary<string, Action<T0, T1, T2>> Channels = new Dictionary<string, Action<T0, T1, T2>>();
	
	protected Action<T0, T1, T2> action;
	
	public void Say(T0 arg0, T1 arg1, T2 arg2)
	{
		if (action != null) action(arg0, arg1, arg2);
	}
	
	public virtual void Subscribe(Action<T0, T1, T2> callback)
	{
		action += callback;
	}
	
	public virtual void Unscribe(Action<T0, T1, T2> callback)
	{
		action -= callback;
	}
	
	
	public void Say(string channel, T0 arg0, T1 arg1, T2 arg2)
	{
		Action<T0, T1, T2> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch(arg0, arg1, arg2);
	}
	
	public virtual void Subscribe(string channel, Action<T0, T1, T2> callback)
	{
		Action<T0, T1, T2> ch;
		if (!Channels.TryGetValue(channel, out ch))
			Channels.Add(channel, callback);
		else
			ch += callback;
	}
	
	public virtual void Unscribe(string channel, Action<T0, T1, T2> callback)
	{
		Action<T0, T1, T2> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch -= callback;
	}
}

public class Message<T0, T1, T2, T3>
{
	protected readonly Dictionary<string, Action<T0, T1, T2, T3>> Channels = new Dictionary<string, Action<T0, T1, T2, T3>>();
	
	protected Action<T0, T1, T2, T3> action;
	
	public void Say(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		if (action != null) action(arg0, arg1, arg2, arg3);
	}
	
	public virtual void Subscribe(Action<T0, T1, T2, T3> callback)
	{
		action += callback;
	}
	
	public virtual void Unscribe(Action<T0, T1, T2, T3> callback)
	{
		action -= callback;
	}
	
	public void Say(string channel, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		Action<T0, T1, T2, T3> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch(arg0, arg1, arg2, arg3);
	}
	
	public virtual void Subscribe(string channel, Action<T0, T1, T2, T3> callback)
	{
		Action<T0, T1, T2, T3> ch;
		if (!Channels.TryGetValue(channel, out ch))
			Channels.Add(channel, callback);
		else
			ch += callback;
	}
	
	public virtual void Unscribe(string channel, Action<T0, T1, T2, T3> callback)
	{
		Action<T0, T1, T2, T3> ch;
		if (Channels.TryGetValue(channel, out ch))
			ch -= callback;
	}
}

public class SingleMessage : Message
{
	public override void Subscribe(Action callback)
	{
		action = callback;
	}
	
	public override void Unscribe(Action callback)
	{
		action = null;
	}
	
	public override void Subscribe(string channel, Action callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public override void Unscribe(string channel, Action callback)
	{
		Action ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class SingleMessage<T0> : Message<T0>
{
	public override void Subscribe(Action<T0> callback)
	{
		action = callback;
	}
	
	public override void Unscribe(Action<T0> callback)
	{
		action = null;
	}
	
	public override void Subscribe(string channel, Action<T0> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public override void Unscribe(string channel, Action<T0> callback)
	{
		Action<T0> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class SingleMessage<T0, T1> : Message<T0, T1>
{
	public override void Subscribe(Action<T0, T1> callback)
	{
		action = callback;
	}
	
	public override void Unscribe(Action<T0, T1> callback)
	{
		action = null;
	}
	
	public override void Subscribe(string channel, Action<T0, T1> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public override void Unscribe(string channel, Action<T0, T1> callback)
	{
		Action<T0, T1> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class SingleMessage<T0, T1, T2> : Message<T0, T1, T2>
{
	public override void Subscribe(Action<T0, T1, T2> callback)
	{
		action = callback;
	}
	
	public override void Unscribe(Action<T0, T1, T2> callback)
	{
		action = null;
	}
	
	public override void Subscribe(string channel, Action<T0, T1, T2> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public override void Unscribe(string channel, Action<T0, T1, T2> callback)
	{
		Action<T0, T1, T2> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class SingleMessage<T0, T1, T2, T3> : Message<T0, T1, T2, T3>
{
	public override void Subscribe(Action<T0, T1, T2, T3> callback)
	{
		action = callback;
	}
	
	public override void Unscribe(Action<T0, T1, T2, T3> callback)
	{
		action = null;
	}
	
	public override void Subscribe(string channel, Action<T0, T1, T2, T3> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public override void Unscribe(string channel, Action<T0, T1, T2, T3> callback)
	{
		Action<T0, T1, T2, T3> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class FuncMessage<TResult>
{
	protected readonly Dictionary<string, Func<TResult>> Channels = new Dictionary<string, Func<TResult>>();
	
	protected Func<TResult> func;
	
	public TResult Say()
	{
		if (func != null) return func();
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(Func<TResult> callback)
	{
		func = callback;
	}
	
	public virtual void Unscribe(Func<TResult> callback)
	{
		if(callback == func)
			func = null;
	}
	
	public TResult Say(string channel)
	{
		Func<TResult> ch;
		if (Channels.TryGetValue(channel, out ch))
			return ch();
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(string channel, Func<TResult> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public virtual void Unscribe(string channel, Func<TResult> callback)
	{
		Func<TResult> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class FuncMessage<T0, TResult>
{
	protected readonly Dictionary<string, Func<T0, TResult>> Channels = new Dictionary<string, Func<T0, TResult>>();
	
	protected Func<T0, TResult> func;
	
	public TResult Say(T0 arg0)
	{
		if (func != null) return func(arg0);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(Func<T0, TResult> callback)
	{
		func = callback;
	}
	
	public virtual void Unscribe(Func<T0, TResult> callback)
	{
		if (callback == func)
			func = null;
	}
	
	public TResult Say(string channel, T0 arg0)
	{
		Func<T0, TResult> ch;
		if (Channels.TryGetValue(channel, out ch))
			return ch(arg0);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(string channel, Func<T0, TResult> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public virtual void Unscribe(string channel, Func<T0, TResult> callback)
	{
		Func<T0, TResult> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class FuncMessage<T0, T1, TResult>
{
	protected readonly Dictionary<string, Func<T0, T1, TResult>> Channels = new Dictionary<string, Func<T0, T1, TResult>>();
	
	protected Func<T0, T1, TResult> func;
	
	public TResult Say(T0 arg0, T1 arg1)
	{
		if (func != null) return func(arg0, arg1);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(Func<T0, T1, TResult> callback)
	{
		func = callback;
	}
	
	public virtual void Unscribe(Func<T0, T1, TResult> callback)
	{
		if (callback == func)
			func = null;
	}
	
	public TResult Say(string channel, T0 arg0, T1 arg1)
	{
		Func<T0, T1, TResult> ch;
		if (Channels.TryGetValue(channel, out ch))
			return ch(arg0, arg1);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(string channel, Func<T0, T1, TResult> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public virtual void Unscribe(string channel, Func<T0, T1, TResult> callback)
	{
		Func<T0, T1, TResult> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class FuncMessage<T0, T1, T2, TResult>
{
	protected readonly Dictionary<string, Func<T0, T1, T2, TResult>> Channels = new Dictionary<string, Func<T0, T1, T2, TResult>>();
	
	protected Func<T0, T1, T2, TResult> func;
	
	public TResult Say(T0 arg0, T1 arg1, T2 arg2)
	{
		if (func != null) return func(arg0, arg1, arg2);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(Func<T0, T1, T2, TResult> callback)
	{
		func = callback;
	}
	
	public virtual void Unscribe(Func<T0, T1, T2, TResult> callback)
	{
		if (callback == func)
			func = null;
	}
	
	public TResult Say(string channel, T0 arg0, T1 arg1, T2 arg2)
	{
		Func<T0, T1, T2, TResult> ch;
		if (Channels.TryGetValue(channel, out ch))
			return ch(arg0, arg1, arg2);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(string channel, Func<T0, T1, T2, TResult> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public virtual void Unscribe(string channel, Func<T0, T1, T2, TResult> callback)
	{
		Func<T0, T1, T2, TResult> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class FuncMessage<T0, T1, T2, T3, TResult>
{
	protected readonly Dictionary<string, Func<T0, T1, T2, T3, TResult>> Channels = new Dictionary<string, Func<T0, T1, T2, T3, TResult>>();
	
	protected Func<T0, T1, T2, T3, TResult> func;
	
	public TResult Say(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		if (func != null) return func(arg0, arg1, arg2, arg3);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(Func<T0, T1, T2, T3, TResult> callback)
	{
		func = callback;
	}
	
	public virtual void Unscribe(Func<T0, T1, T2, T3, TResult> callback)
	{
		if (callback == func)
			func = null;
	}
	
	public TResult Say(string channel, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		Func<T0, T1, T2, T3, TResult> ch;
		if (Channels.TryGetValue(channel, out ch))
			return ch(arg0, arg1, arg2, arg3);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(string channel, Func<T0, T1, T2, T3, TResult> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public virtual void Unscribe(string channel, Func<T0, T1, T2, T3, TResult> callback)
	{
		Func<T0, T1, T2, T3, TResult> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

public class PriorityMessage<T0, TResult>
{
	protected readonly Dictionary<string, Func<T0, TResult>> Channels = new Dictionary<string, Func<T0, TResult>>();
	
	protected Func<T0, TResult> func;
	
	public TResult Say(T0 arg0)
	{
		if (func != null) return func(arg0);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(Func<T0, TResult> callback)
	{
		func = callback;
	}
	
	public virtual void Unscribe(Func<T0, TResult> callback)
	{
		if (callback == func)
			func = null;
	}
	
	public TResult Say(string channel, T0 arg0)
	{
		Func<T0, TResult> ch;
		if (Channels.TryGetValue(channel, out ch))
			return ch(arg0);
		Debug.LogWarning("You invoke null func");
		return default(TResult);
	}
	
	public virtual void Subscribe(string channel, Func<T0, TResult> callback)
	{
		if (Channels.ContainsKey(channel))
			Channels[channel] = callback;
		else Channels.Add(channel, callback);
	}
	
	public virtual void Unscribe(string channel, Func<T0, TResult> callback)
	{
		Func<T0, TResult> ch;
		if (Channels.TryGetValue(channel, out ch) && ch == callback)
			Channels.Remove(channel);
	}
}

