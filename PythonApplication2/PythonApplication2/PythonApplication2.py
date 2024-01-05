from flask import Flask, redirect, request, render_template
import spotipy
from spotipy.oauth2 import SpotifyOAuth

app = Flask(__name__)

# Ключи и настройки вашего Spotify приложения
SPOTIPY_CLIENT_ID = 'YOUR_CLIENT_ID'
SPOTIPY_CLIENT_SECRET = 'YOUR_CLIENT_SECRET'
SPOTIPY_REDIRECT_URI = 'YOUR_REDIRECT_URI'

# Объект конфигурации для Spotify OAuth
sp_oauth = SpotifyOAuth(SPOTIPY_CLIENT_ID, SPOTIPY_CLIENT_SECRET, SPOTIPY_REDIRECT_URI, scope='user-library-read user-read-playback-state user-modify-playback-state user-read-currently-playing')

# Главная страница
@app.route('/')
def index():
    return render_template('index.html')

# Страница для обработки авторизации через Spotify
@app.route('/login')
def login():
    auth_url = sp_oauth.get_authorize_url()
    return redirect(auth_url)

# Страница для обработки коллбэка после авторизации
@app.route('/callback')
def callback():
    token_info = sp_oauth.get_access_token(request.args['code'])
    return render_template('callback.html', token_info=token_info)

# Страница для воспроизведения трека
@app.route('/play')
def play():
    # Здесь вы можете использовать токен для вызова Spotify API и воспроизведения трека
    # Пример: использование spotipy для воспроизведения первого трека из библиотеки пользователя
    sp = spotipy.Spotify(auth=token_info['access_token'])
    results = sp.current_user_saved_tracks()
    first_track_uri = results['items'][0]['track']['uri']
    sp.start_playback(uris=[first_track_uri])

    return "Трек начал воспроизводиться."

if __name__ == '__main__':
    app.run(debug=True)
